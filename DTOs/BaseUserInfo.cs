using System.ComponentModel.DataAnnotations;
public readonly record struct BaseUserInfo(
    [StringLength(30), MinLength(8)]
    [Required]
    string UserName,
    [Required]
    [StringLength(30), MinLength(4)]
    string FullName,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [Range(1,100)]
    int Age,
    [Required]
    [Phone]
    string Phone
);