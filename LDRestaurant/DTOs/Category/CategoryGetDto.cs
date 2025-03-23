using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDRestaurant.DTOs.Category;
public record CategoryGetDto
{
    public string Id { get; set; }  //dto-da id string olur
    public string Name { get; set; }
}
