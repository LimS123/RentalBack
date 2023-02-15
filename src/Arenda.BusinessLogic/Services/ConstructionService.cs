using Arenda.BusinessLogic.Contracts;
using Arenda.BusinessLogic.Contracts.Providers;
using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Contracts.Providers;
using Arenda.DataAccess.Contracts.Repositories;
using Arenda.DataAccess.Entities;
using Arenda.DataAccess.Models;
using AutoMapper;

namespace Arenda.BusinessLogic.Services
{
    public class ConstructionService :  IConstructionService
    {
        private readonly IConstructionProvider _constructionProvider;
        private readonly IUserConstructionsProvider _userConstructionsProvider;
        private readonly IUserProvider _userProvider;
        private readonly IHttpContextProvider _httpContextProvider;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IConstructionRepository _constructionRepository;
        private readonly IUserConstructionsRepository _userConstructionsRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public ConstructionService(
            IConstructionProvider constructionProvider,
            IUserConstructionsProvider userConstructionsProvider,
            IUserProvider userProvider,
            IHttpContextProvider httpContextProvider,
            IDateTimeProvider dateTimeProvider,
            IConstructionRepository constructionRepository,
            IUserConstructionsRepository userConstructionsRepository,
            IImageRepository imageRepository,
            IDataContext dataContext,
            IMapper mapper)
        {
            _constructionProvider = constructionProvider;
            _userConstructionsProvider = userConstructionsProvider;
            _userProvider = userProvider;
            _httpContextProvider = httpContextProvider;
            _dateTimeProvider = dateTimeProvider;
            _constructionRepository = constructionRepository;
            _userConstructionsRepository = userConstructionsRepository;
            _imageRepository = imageRepository;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Models.Construction> CreateConstruction(Models.CreateConstruction createConstruction, CancellationToken token)
        {
            var userId = _httpContextProvider.GetUserId();
            var hasAnyById = await _userProvider.HasAnyById(userId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("User doesn't exist");
            }
            var user = await _userProvider.GetById(userId, token);

            var construction = new Construction()
            {
                Price = createConstruction.Price,
                Name = createConstruction.Name,
                Region = createConstruction.Region,
                City = createConstruction.City,
                Street = createConstruction.Street,
                HouseNumber = createConstruction.HouseNumber,
                Type = StringToConstructionType(createConstruction.Type),
                Square = createConstruction.Square,
                Year = createConstruction.Year,
                Description = createConstruction.Description,
                NumberOfRooms = createConstruction.NumberOfRooms,
                Floor = createConstruction.Floor,
                CreatedAtUtc = _dateTimeProvider.NowUtc
            };

            _constructionRepository.Create(construction);

            foreach(var image in createConstruction.Images)
            {
                var newImage = new Image()
                {
                    Data = image.Item1,
                    MediaType = image.Item2
                };

                _imageRepository.Create(newImage);

                construction.Images.Add(newImage);
            }

            _userConstructionsRepository.Create(new UserConstruction { User = user, Construction = construction });

            await _dataContext.SaveChanges(token);

            var result = new Models.Construction()
            {
                Id = construction.Id,
                Price = construction.Price,
                CreatedAtUtc = construction.CreatedAtUtc,
                Name = construction.Name,
                Region = construction.Region,
                City = construction.City,
                Street = construction.Street,
                HouseNumber = construction.HouseNumber,
                Type = ConstructionTypeToString(construction.Type),
                Square = construction.Square,
                Year = construction.Year,
                Description = construction.Description,
                NumberOfRooms = construction.NumberOfRooms,
                Floor = construction.Floor
            };

            foreach(var image in construction.Images)
            {
                result.Images!.Add(new() {
                    Id = image.Id,
                    DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                });
            }

            return result;
        }

        public async Task<List<Models.Construction>> GetAllConstructions(int page, int size, CancellationToken token)
        {
            var constructions = await _constructionProvider.GetAll(page, size, token);

            var result = new List<Models.Construction>();

            foreach(var construction in constructions)
            {
                var resultConstruction = new Models.Construction()
                {
                    Id = construction.Id,
                    Price = construction.Price,
                    CreatedAtUtc = construction.CreatedAtUtc,
                    Name = construction.Name,
                    Region = construction.Region,
                    City = construction.City,
                    Street = construction.Street,
                    HouseNumber = construction.HouseNumber,
                    Type = ConstructionTypeToString(construction.Type),
                    Square = construction.Square,
                    Year = construction.Year,
                    Description = construction.Description,
                    NumberOfRooms = construction.NumberOfRooms,
                    Floor = construction.Floor
                };

                foreach (var image in construction.Images)
                {
                    resultConstruction.Images?.Add(new()
                    {
                        Id = image.Id,
                        DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                    });
                }

                result.Add(resultConstruction);
            }

            return result;
        }

        public async Task<List<Models.Construction>> GetAllConstructionsByUserId(Guid userId, CancellationToken token)
        {
            var constructions = await _userConstructionsProvider.GetConstructionsByUserId(userId, token);

            var result = new List<Models.Construction>();

            foreach (var construction in constructions)
            {
                var resultConstruction = new Models.Construction()
                {
                    Id = construction.Id,
                    Price = construction.Price,
                    CreatedAtUtc = construction.CreatedAtUtc,
                    Name = construction.Name,
                    Region = construction.Region,
                    City = construction.City,
                    Street = construction.Street,
                    HouseNumber = construction.HouseNumber,
                    Type = ConstructionTypeToString(construction.Type),
                    Square = construction.Square,
                    Year = construction.Year,
                    Description = construction.Description,
                    NumberOfRooms = construction.NumberOfRooms,
                    Floor = construction.Floor
                };

                foreach (var image in construction.Images)
                {
                    resultConstruction.Images?.Add(new()
                    {
                        Id = image.Id,
                        DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                    });
                }

                result.Add(resultConstruction);
            }

            return result;
        }

        public async Task<List<Models.Construction>> GetAllConstructionsByFilter(Models.ConstructionFilter constructionFilter, int page, int size, CancellationToken token)
        {
            var filter = _mapper.Map<Models.ConstructionFilter, ConstructionFilter>(constructionFilter);

            var constructions = await _constructionProvider.GetAllByFilter(filter, page, size, token);

            var result = new List<Models.Construction>();

            foreach (var construction in constructions)
            {
                var resultConstruction = new Models.Construction()
                {
                    Id = construction.Id,
                    Price = construction.Price,
                    CreatedAtUtc = construction.CreatedAtUtc,
                    Name = construction.Name,
                    Region = construction.Region,
                    City = construction.City,
                    Street = construction.Street,
                    HouseNumber = construction.HouseNumber,
                    Type = ConstructionTypeToString(construction.Type),
                    Square = construction.Square,
                    Year = construction.Year,
                    Description = construction.Description,
                    NumberOfRooms = construction.NumberOfRooms,
                    Floor = construction.Floor
                };

                foreach (var image in construction.Images)
                {
                    resultConstruction.Images?.Add(new()
                    {
                        Id = image.Id,
                        DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                    });
                }

                result.Add(resultConstruction);
            }

            return result;
        }

        public async Task<Models.Construction> GetConstruction(Guid constructionId, CancellationToken token)
        {
            var hasAnyById = await _constructionProvider.HasAnyById(constructionId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("Construction doesn't exist");
            }

            var construction = await _constructionProvider.GetByIdIncludeUserConstructions(constructionId, token);
            var user = await _userProvider.GetById(construction.UserConstructions[0].UserId, token);

            var result = new Models.Construction()
            {
                Id = construction!.Id,
                UserId = user.Id,
                PhoneNumber = user.PhoneNumber,
                Price = construction.Price,
                CreatedAtUtc = construction.CreatedAtUtc,
                Name = construction.Name,
                Region = construction.Region,
                City = construction.City,
                Street = construction.Street,
                HouseNumber = construction.HouseNumber,
                Type = ConstructionTypeToString(construction.Type),
                Square = construction.Square,
                Year = construction.Year,
                Description = construction.Description,
                NumberOfRooms = construction.NumberOfRooms,
                Floor = construction.Floor
            };

            foreach (var image in construction.Images)
            {
                result.Images?.Add(new()
                {
                    Id = image.Id,
                    DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                });
            }

            return result;
        }

        public async Task<Models.Construction> UpdateConstruciton(Models.UpdateConstruction updateConstruction, CancellationToken token)
        {
            var hasAnyById = await _constructionProvider.HasAnyById(updateConstruction.Id, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("Construction doesn't exist");
            }

            var construction = await _constructionProvider.GetById(updateConstruction.Id, token);

            construction!.Price = updateConstruction.Price;
            construction.Name = updateConstruction.Name;
            construction.Region = updateConstruction.Region;
            construction.City = updateConstruction.City;
            construction.Street = updateConstruction.Street;
            construction.HouseNumber = updateConstruction.HouseNumber;
            construction.Type = StringToConstructionType(updateConstruction.Type);
            construction.Square = updateConstruction.Square;
            construction.Year = updateConstruction.Year;
            construction.Description = updateConstruction.Description;
            construction.NumberOfRooms = updateConstruction.NumberOfRooms;
            construction.Floor = updateConstruction.Floor;

            var currentImages = new List<Guid>();

            foreach (var currentImage in construction.Images)
            {
                currentImages.Add(currentImage.Id);
            }

            var deletedImages = currentImages.Except(updateConstruction.Images);

            foreach (var id in deletedImages)
            {
                var image = construction.Images.FirstOrDefault(x => x.Id == id);

                construction.Images.Remove(image);

                _imageRepository.Delete(image);
            }

            foreach (var image in updateConstruction.NewImages)
            {
                var newImage = new Image()
                {
                    Data = image.Item1,
                    MediaType = image.Item2
                };

                _imageRepository.Create(newImage);

                construction.Images.Add(newImage);
            }

            _constructionRepository.Update(construction);
            await _dataContext.SaveChanges(token);

            var result = new Models.Construction()
            {
                Id = construction!.Id,
                Price = construction.Price,
                CreatedAtUtc = construction.CreatedAtUtc,
                Name = construction.Name,
                Region = construction.Region,
                City = construction.City,
                Street = construction.Street,
                HouseNumber = construction.HouseNumber,
                Type = ConstructionTypeToString(construction.Type),
                Square = construction.Square,
                Year = construction.Year,
                Description = construction.Description,
                NumberOfRooms = construction.NumberOfRooms,
                Floor = construction.Floor
            };

            foreach (var image in construction.Images)
            {
                result.Images?.Add(new()
                {
                    Id = image.Id,
                    DataInBase64 = $"data:{image.MediaType};base64,{Convert.ToBase64String(image.Data)}"
                });
            }

            return result;
        }

        public async Task RemoveConstruciton(Guid constructionId, CancellationToken token)
        {
            var hasAnyById = await _constructionProvider.HasAnyById(constructionId, token);

            if (!hasAnyById)
            {
                throw new ApplicationException("Construction doesn't exist");
            }

            var construction = await _constructionProvider.GetById(constructionId, token);

            _constructionRepository.Delete(construction!);
            await _dataContext.SaveChanges(token);
        }

        private ConstructionType StringToConstructionType(string type) => type switch
        {
            "Apartment" => ConstructionType.Apartment,
            "Room" => ConstructionType.Room,
            "House" => ConstructionType.House,
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected direction value: {type}"),
        };

        private string ConstructionTypeToString(ConstructionType type) => type switch
        {
            ConstructionType.Apartment => "Apartment",
            ConstructionType.Room => "Room",
            ConstructionType.House => "House",
            ConstructionType.Unspecified => throw new ArgumentException(nameof(type), $"Not found construction type: {type}"),
            _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected direction value: {type}"),
        };
    }
}
