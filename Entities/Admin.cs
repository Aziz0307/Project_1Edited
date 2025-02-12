namespace Project1_Edited.Entities
{
    namespace Project1
    {
        public class Admin : User
        {
            public Admin()
            {
                UserRole = Role.Admin;
            }
        }
    }

}