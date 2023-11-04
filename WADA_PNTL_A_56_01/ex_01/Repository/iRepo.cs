using ex_01.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_01.Repository
{
    public interface iRepo
    {
        IEnumerable<Donetor> getAll();
        Donetor getById(int dId);
        void insert(Donetor inDonetor);
        void update(Donetor upDonetor);
        void deleteById(int dId);

    }
}
