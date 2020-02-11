using POC.Core.Models;

namespace POC.Core
{
    public interface IEmployeeRepository
    {
        Employee Get();
        string GetEmployee();
    }
}
