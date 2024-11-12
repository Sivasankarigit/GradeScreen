using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeScreenWeb.Models;
using GradeScreenWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace GradeScreenWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController:ControllerBase
    {
        private readonly IGrade _iGrade;

        public GradeController(IGrade iGrade){
            _iGrade=iGrade;
        }

        [HttpGet]
        public IActionResult GetGrades(){
            try
            {
                var result=_iGrade.GetGrades();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("InsertGrade")]

        public IActionResult InsertGrade([FromBody] GradeEntity gradeEntity){
            try{
                _iGrade.InsertGrade(gradeEntity);
                return Ok("Grade Inserted Successfully");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateGrade")]

        public async Task<IActionResult> UpdateGrade(GradeEntity gradeEntity,[FromQuery] int id){
            try{
                var updatedGrade=await _iGrade.UpdateGrade(id,gradeEntity);
                return Ok(updatedGrade);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetId/{id}")]

        public async Task<ActionResult<GradeEntity>> GetbyId(int id){
            try{
                var grade = await _iGrade.getGradebyId(id);
                return Ok(grade);
            }
            catch(InvalidOperationException ex){
                return NotFound(ex.Message);
            } 
        }
        
    }
}



