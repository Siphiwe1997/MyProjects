namespace MyJourney.Data
{
    public interface IRepositoryWrapper
    {
        IMatricRepository Matric { get; }
        IModuleRepository Module { get; }   
        IContactRepository Contact { get; }
        ISkillRepository Skill { get; }
        void Save();
    }
}
