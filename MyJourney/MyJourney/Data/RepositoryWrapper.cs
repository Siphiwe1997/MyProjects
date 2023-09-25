namespace MyJourney.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _appDbContext;
        private IMatricRepository _matric;
        private IModuleRepository _module;
        private IContactRepository _contact;
        private ISkillRepository _skill;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IMatricRepository Matric
        {
            get
            {
                if(_matric == null)
                {
                    _matric = new MatricRepository(_appDbContext);
                }
                return _matric;
            }
        }

        public IModuleRepository Module
        {
            get
            {
                if(_module == null)
                {
                    _module = new ModuleRepository(_appDbContext);
                }
                return _module; 
            }
        }

        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact= new ContactRepository(_appDbContext);
                }
                return _contact;
            }
        }
        public ISkillRepository Skill
        {
            get
            {
                if (_skill == null)
                {
                    _skill = new SkillRepository(_appDbContext);
                }
                return _skill;
            }
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
