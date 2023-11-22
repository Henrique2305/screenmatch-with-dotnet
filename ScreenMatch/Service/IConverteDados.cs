using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenMatch.Service;

public interface IConverteDados
{
    T ObterDados<T>(string json);
}

