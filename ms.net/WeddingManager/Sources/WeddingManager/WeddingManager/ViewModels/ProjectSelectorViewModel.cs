using DataSource.DataContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualControls.ModalContentHandler;
using WeddingManager.MVVM;

namespace WeddingManager.ViewModels
{
    public class ProjectSelectorViewModel : WeddingManagerViewModelBase, IModalContent
    {
        private Guid? _selectedProjectId = null;
        private List<WeddingProject> _availableProjects;
        private readonly RelayCommand _createProject;

        public ProjectSelectorViewModel()
        {
            _createProject = new RelayCommand(CreateProject);

        }

        public Guid? SelectedProjectId
        {
            get { return _selectedProjectId ?? (_selectedProjectId = AvailableProjects.First().Id); }

            set
            {
                _selectedProjectId = value;
                OnPropertyChanged("SelectedProjectId");
            }
        }

        public ReadOnlyCollection<WeddingProject> AvailableProjects
        {
            get
            {
                if (_availableProjects == null)
                {
                    _availableProjects = new List<WeddingProject> { new WeddingProject() { Id = Guid.Empty, Name = "- Create new one -" } };

                    //TODO: Testing. Remove
                    _availableProjects.Add(new WeddingProject() { Id = Guid.NewGuid(), Name = "Test" });

                    _availableProjects.AddRange(DataContext.WeddingProjects.ToList());
                }

                return _availableProjects.AsReadOnly();
            }
        }

        private void CreateProject(object param)
        {
            throw new NotImplementedException();
        }

        #region IModalContent
        public void OnOkPressed()
        {
            //throw new NotImplementedException();
        }

        public void OnCancelPressed()
        {
            OnExitPressed();
        }

        public void OnSavePressed()
        {
            throw new NotImplementedException();
        }

        public void OnExitPressed()
        {
            // Do nothing
        }
        #endregion
    }
}
