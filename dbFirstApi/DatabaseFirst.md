


## Scaffold command
```bash
dotnet user-secrets set ConnectionStrings:DefaultConnection "Server=localhost,1433; Database=BookStoresDB; User=sa; Password =YourPassword123; Trusted_Connection=false; TrustServerCertificate=true;" 

dotnet ef dbcontext scaffold Name=ConnectionStrings:DefaultConnection Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context ApplicationDbContext --context-dir DataConnections --data-annotations```

### Packages needed to install
```bash
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="7.0.11" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.11">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.11">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.11" />
  </ItemGroup>

``

## Ignoring Jsonseralization for circular dependancy

[JsonIgnore]
    [ForeignKey("AuthorId")]
    [InverseProperty("BookAuthors")]
    public virtual Author Author { get; set; } = null!;