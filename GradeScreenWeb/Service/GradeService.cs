using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeScreenWeb.Context;
using GradeScreenWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GradeScreenWeb.Service
{
    public class GradeService:IGrade
    {
        private readonly GradeContext _context;

        public GradeService(GradeContext context){
            _context=context;
        }

        // Get all grades

        public IEnumerable<GradeEntity> GetGrades(){
            return _context.Grades.ToList();
        }

        // Insert a grade
        public void InsertGrade(GradeEntity gradeEntity){
            _context.Grades.Add(gradeEntity);
            _context.SaveChanges();
        }

        // Update a grade
  public async Task<GradeEntity> UpdateGrade(int id, GradeEntity updatedEntity)
{
    using (var transaction = _context.Database.BeginTransaction())
    {
        try
        {
            var existingEntity = await _context.Grades.FindAsync(id);
            if (existingEntity == null)
            {
                // Handle the case where the entity with the specified id is not found
                // For example, throw an exception or return null
                throw new Exception($"Entity with id {id} not found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            transaction.Commit();
            return existingEntity;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
    }
}
// 

        // Get grade by id

        public async Task<GradeEntity> getGradebyId(int id){
            try{
                var grade = await _context.Grades.FirstOrDefaultAsync(g => g.gardeId == id);
                if(grade == null){
                    throw new InvalidOperationException("Id not found");
                }
                return grade;
            }
            catch(Exception ex){
                throw ex;
            }
        }
 
    }
}

