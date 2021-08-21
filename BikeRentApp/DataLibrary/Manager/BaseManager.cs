namespace DataLibrary.Manager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BaseManager<T> where T : class, new()
    {
        #region Properties
        public readonly BikeRentContext dbContext = new BikeRentContext();
        public T EntityModel { get; set; }
        public List<T> EntityModelList { get; set; }
        public virtual List<T> GetData
        {
            get
            {
                try
                {
                    return dbContext.Set<T>().ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion


        #region Constructor
        public BaseManager(bool ProxyCreationEnabled = true)
        {
            dbContext.Configuration.ProxyCreationEnabled = ProxyCreationEnabled;
        }
        #endregion


        #region Methods
        public virtual bool Save(T EntityModel, bool isNew = true)
        {
            try
            {
                if (isNew)
                {
                    dbContext.Entry<T>(EntityModel).State = EntityState.Added;
                }
                else
                {
                    dbContext.Entry<T>(EntityModel).State = EntityState.Modified;
                }

                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static TC CreateIntanceForClassInModel<TO, TC>(TO ClassEntytyFromCopy, ref TC ClassModelToCopy, List<string> PropertiesExclude = null) where TO : class, new() where TC : class, new()
        {

            var PropT = typeof(TO);
            foreach (var p in PropT.GetProperties())
            {
                bool evaluate = true;
                if (PropertiesExclude != null && PropertiesExclude.Contains(p.Name)) evaluate = false;
                var attribute = p.GetCustomAttributes(typeof(DefaultValueAttribute), false).FirstOrDefault() as DefaultValueAttribute;

                dynamic SetValor;
                if (p.CanWrite && PropT.GetProperty(p.Name).GetValue(ClassEntytyFromCopy, null) != null && evaluate)
                {
                    var entityProperty = ClassModelToCopy.GetType().GetProperty(p.Name);
                    if (entityProperty != null)
                    {
                        SetValor = PropT.GetProperty(p.Name).GetValue(ClassEntytyFromCopy, null);
                        if (attribute != null && attribute.Value != SetValor)
                            evaluate = false;
                        if (evaluate) p.SetValue(ClassModelToCopy, SetValor, null);
                    }
                }

            }
            return ClassModelToCopy;
        }

        #endregion
    }
}
