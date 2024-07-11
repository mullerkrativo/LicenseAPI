using Reliance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Core.Interfaces
{
    public interface ISuperUserService
    {
        IEnumerable<Licensetable> GetAllLicense(int page = 1);
        string CreateLicense(Licensetable model);
    }
}
