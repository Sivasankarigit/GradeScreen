using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeScreenWeb.Models;

namespace GradeScreenWeb.Service
{
    public interface IGrade
    {
        IEnumerable<GradeEntity> GetGrades();
        void InsertGrade(GradeEntity gradeEntity);

        // Task<GradeEntity> UpdateGrade(GradeEntity gradeEntity);
  Task<GradeEntity> UpdateGrade(int id, GradeEntity updatedEntity);
        Task<GradeEntity> getGradebyId(int id);
        
    }
}