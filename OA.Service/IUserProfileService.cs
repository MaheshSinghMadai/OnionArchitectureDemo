using OA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
    public interface IUserProfileService
    {
        UserProfile GetUserProfile(long id);
    }
}
