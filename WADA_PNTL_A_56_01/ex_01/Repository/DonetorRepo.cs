using ex_01.CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_01.Repository
{
    public class DonetorRepo : DonetorDB, iRepo
    {

        public IEnumerable<Donetor> getAll()
        {
            return donetorList;
        }

        public Donetor getById(int dId)
        {
            Donetor getId = donetorList.FirstOrDefault(d => d.donetorId==dId);
            return getId;
        }

        public void insert(Donetor inDonetor)
        {
            donetorList.Add(inDonetor);
        }

        public void update(Donetor upDonetor)
        {
            Donetor updateDonetor = donetorList.FirstOrDefault(d => d.donetorId == upDonetor.donetorId);
            if (upDonetor.donetorName != null)
            {
                updateDonetor.donetorName = upDonetor.donetorName;
            }
            if (upDonetor.donetorAge != 0)
            { 
                updateDonetor.donetorAge = upDonetor.donetorAge;
            }
            if (upDonetor.donetorBloodGroup != null)
            {
                updateDonetor.donetorBloodGroup = upDonetor.donetorBloodGroup;
            }
        }
        public void deleteById(int dId)
        {
            Donetor getId = donetorList.FirstOrDefault(d => d.donetorId == dId);
            donetorList.Remove(getId);
        }

    }
}
