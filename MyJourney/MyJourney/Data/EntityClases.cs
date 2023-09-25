using MyJourney.Models;

namespace MyJourney.Data
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
    public class MatricRepository : RepositoryBase<Subject>, IMatricRepository
    {
        public MatricRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
    public class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
