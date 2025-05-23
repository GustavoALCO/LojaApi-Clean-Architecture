﻿using loja_api.domain.Entities.auxiliar;
using System.ComponentModel.DataAnnotations;

namespace loja_api.domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Position { get; set; }

    public bool IsActive { get; set; }

    public Auditable Auditable { get; set; }
}
