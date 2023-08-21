
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.MasterRepositories;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;
using OnlineExam.Infrastructure.UnitOfWork;
using OnlineExamApi.Project.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Configure Cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

});
#endregion
#region configure Database
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionstring));
#endregion

#region AutoMapper Configure

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion
#region
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IAccountDetailRepository, AccountDetailRepository>();
//builder.Services.AddScoped<IAddressDetailRepository, AddressDetailRepository>();
//builder.Services.AddScoped<IContectDetailRepository, ContectDetailRepository>();
//builder.Services.AddScoped<IEducationDetailRepository, EducationDetailRepository>();
//builder.Services.AddScoped<IExperienceDetailRepository, ExperienceDetailRepository>();
//builder.Services.AddScoped<IPersonalDetailRepository, PersonalDetailRepository>();
//builder.Services.AddScoped<IFamilyDetailRepository, FamilyDetailRepository>();
builder.Services.AddScoped<IBankNameRepository, BankNameRepository>();
builder.Services.AddScoped<IBranchNameRepository, BranchNameRepository>();
builder.Services.AddScoped<IifscCodeRepository, IFSCCodeRepository>();
builder.Services.AddScoped<IBloodGroupRepository, BloodGroupRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
builder.Services.AddScoped<IReligionNameRepository, ReligionNameRepository>();
builder.Services.AddScoped<IRelationshipDetailRepository, RelationshipDetailRepository>();
builder.Services.AddScoped<IOccupationDetailRepository, OccupationDetailRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IDesignationDetailRepository, DesignationDetailRepository>();
builder.Services.AddScoped<IExperienceRoleRepository, ExperienceRoleRepository>();
builder.Services.AddScoped<IAccountTypeRepository, AccountRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CustomPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
