using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Entities;
namespace ConsoleApp5.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        List<Department> _list;
        public DepartmentRepository()
        {
            _list = new List<Department>();
        }
        public void Delete(int id)
        {
            Department d = GetById(id);
            if (d != null)
                _list.Remove(d);
        }

        public IEnumerable<Department> GetAll()
        {
            return _list;
        }

        public Department GetById(int id)
        {
            foreach (var item in _list)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public void Insert(Department entity)
        {
            _list.Add(entity);
        }

        public void Update(Department entity)
        {
            Department d = GetById(entity.Id);
            if (d != null)
            {
                d.Location = entity.Location;
                d.Name = entity.Name;
            }
        }
    }
}
