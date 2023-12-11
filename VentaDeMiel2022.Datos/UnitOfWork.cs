namespace VentaDeMiel2022.Datos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VentaDeMiel2022DbContext context;
        public UnitOfWork(VentaDeMiel2022DbContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
