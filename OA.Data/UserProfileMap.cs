﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data
{
    public class UserProfileMap
    {

        //specifying requirements
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Address);
        }
    }
}
