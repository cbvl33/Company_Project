using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Respond;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.Interfaces
{
    public interface ILogin
    {
       LoginResponse Login(ULoginData loginData);
    }
}
