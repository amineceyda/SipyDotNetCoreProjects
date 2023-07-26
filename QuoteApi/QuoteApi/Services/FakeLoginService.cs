namespace QuoteApi.Services
{
    public class FakeLoginService : IFakeLoginService
    {
        private bool _isLoggedIn = false;

        public void FakeLogin()
        {
            _isLoggedIn = true;
        }

        public void FakeLogout()
        {
            _isLoggedIn = false;
        }

        public bool IsUserLoggedIn()
        {
            return _isLoggedIn;
        }
    }
}

//This service should have a method to check if a user is logged in or not.