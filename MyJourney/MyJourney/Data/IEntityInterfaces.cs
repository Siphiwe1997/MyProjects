using MyJourney.Models;

namespace MyJourney.Data
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
    }
    public interface IMatricRepository : IRepositoryBase<Subject>
    {
    }
    public interface IModuleRepository : IRepositoryBase<Module>
    {
    }
    public interface ISkillRepository : IRepositoryBase<Skill>
    {
    }
}
