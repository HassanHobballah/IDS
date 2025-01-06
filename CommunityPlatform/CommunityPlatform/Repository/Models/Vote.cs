using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommunityPlatform.Repository.Models;

public partial class Vote
{
    [Key]
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    [StringLength(10)]
    public string VoteType { get; set; } = null!;

    [ForeignKey("PostId")]
    [InverseProperty("Votes")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Votes")]
    public virtual User User { get; set; } = null!;
}
