﻿using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public Guid? CustomerId { get; set; }
}
