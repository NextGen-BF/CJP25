using AutoMapper;
using NextGen_BM_BE_Application.UseCases.Buildings.Create;
using NextGen_BM_BE_Application.UseCases.Buildings.Delete;
using NextGen_BM_BE_Application.UseCases.Buildings.Get;
using NextGen_BM_BE_Application.UseCases.Buildings.Update;
using NextGen_BM_BE_Domain.Entities.BuildingAggregate;
using NextGen_BM_BE_Domain.Interfaces;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;


namespace NextGen_BM_BE_Application.Services;

public class BuildingService: IBuildingService
{
    private readonly CreateBuildingUseCase _createBuildingUseCase;
    private readonly UpdateBuildingUseCase _updateBuildingUseCase;
    private readonly DeleteBuildingUseCase _deleteBuildingUseCase;
    private readonly GetAllBuildingsUseCase _getAllBuildingsUseCase;
    private readonly GetBuildingByIdUseCase _getBuildingByIdUseCase;
    private readonly IMapper _mapper;
    public BuildingService(IBuildingRepository buildingRepository, IMapper mapper,
    CreateBuildingUseCase createBuildingUseCase, UpdateBuildingUseCase updateBuildingUseCase,
    DeleteBuildingUseCase deleteBuildingUseCase, GetAllBuildingsUseCase getAllBuildingsUseCase, 
    GetBuildingByIdUseCase getBuildingByIdUseCase)
    {
        _mapper = mapper;
        _createBuildingUseCase = createBuildingUseCase;
        _updateBuildingUseCase = updateBuildingUseCase;
        _deleteBuildingUseCase = deleteBuildingUseCase;
        _getAllBuildingsUseCase = getAllBuildingsUseCase;
        _getBuildingByIdUseCase = getBuildingByIdUseCase;
    }

    public async Task CreateBuildingAsync(BuildingViewModel buildingDto){
        var building = _mapper.Map<Building>(buildingDto);
        await _createBuildingUseCase.Execute(building);
    }

    public async Task DeleteBuildingAsync(int buildingId)
    {
        await _deleteBuildingUseCase.Execute(buildingId);
    }

    public async Task<IList<Building>> GetAllBuildingsAsync(){
        return await _getAllBuildingsUseCase.Execute();
    }

    public async Task<Building> GetBuildingByIdAsync(int buildingId)
    {
        return await _getBuildingByIdUseCase.Execute(buildingId);
    }

    public async Task UpdateBuildingAsync(BuildingViewModel buildingDto)
    {
        var building = _mapper.Map<Building>(buildingDto);
        await _updateBuildingUseCase.Execute(building);
    }
}