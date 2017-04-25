using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XI_IT_Project2.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
