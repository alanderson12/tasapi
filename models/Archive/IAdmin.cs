namespace api.models
{
    public interface IAdmin
    {
        void AddUser();
        void RemoveUser(int id);
        void ViewUsers();
        void GrantPermissions(int id);
        Survey CreateSurvey();
        void SetSurvey(Survey value);
    }
}