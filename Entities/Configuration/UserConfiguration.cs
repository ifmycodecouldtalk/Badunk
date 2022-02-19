using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasData
            (
            new UserInfo
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                userName = "mycodecantalk",
                password = "secret!password",
            }
            );
        }
    }

}
