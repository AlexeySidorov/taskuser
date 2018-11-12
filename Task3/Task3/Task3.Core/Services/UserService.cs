using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Core.Data;
using Task3.Core.DataBaseService;
using Task3.Domain.Models;

namespace Task3.Services
{
    public interface IUserService : ICrudServiceAsync<User>
    {
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUser(User user);

        /// <summary>
        /// Добавить пользователей
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task AddUsers(IList<User> users);

        /// <summary>
        /// Получить инфу о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Получить инфу о пользователях
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IList<User>> GetUserByIds(IList<int> ids);

        /// <summary>
        /// Получить инфу о пользователях
        /// </summary>
        /// <returns></returns>
        Task<IList<User>> GetAllUsers(int skip, int count);

        /// <summary>
        /// Есть ли пользователи в базе
        /// </summary>
        /// <returns></returns>
        Task<bool> IsUsers();

        /// <summary>
        /// Количество пользователей
        /// </summary>
        /// <returns></returns>
        Task<int> CountUsers();
    }

    public class UserService : AsyncBaseDataService<User>, IUserService
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IAsyncRepository<Friend> _friendRepository;
        private readonly IAsyncRepository<Tag> _tagRepository;

        public UserService(IAsyncRepository<User> repository, IAsyncRepository<Friend> friendRepository, IAsyncRepository<Tag> tagRepository) : base(repository)
        {
            _repository = repository;
            _friendRepository = friendRepository;
            _tagRepository = tagRepository;
        }

        /// <inheritdoc />
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUser(User user)
        {
            var result = await _repository.GetAsync(u => u.Id == user.Id);
            if (result == null)
            {
                await _repository.CreateAsync(user);

                if (user.Friends?.Count > 0)
                {
                    var friends = user.Friends.Select(f => new Friend() { FriendId = f.FriendId, UserId = user.Id }).ToList();
                    await _friendRepository.CreateAllAsync(friends);
                }

                if (user.Tags?.Count > 0)
                {
                    var tags = user.Tags.Select(t => new Tag() { Name = t, UserId = user.Id }).ToList();
                    await _tagRepository.CreateAllAsync(tags);
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Добавить пользователей
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task AddUsers(IList<User> users)
        {
            foreach (var user in users)
                await AddUser(user);
        }

        /// <inheritdoc />
        /// <summary>
        /// Получить инфу о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(int id)
        {
            var result = await _repository.GetAsync(u => u.Id == id);
            if (result != null)
            {
                result.Friends = await _friendRepository.FetchAsync(f => f.UserId == result.Id);

                var tags = await _tagRepository.FetchAsync(t => t.UserId == result.Id);
                result.Tags = tags.Count == 0 ? new List<string>() : tags.Select(t => t.Name).ToList();
            }

            return result;
        }

        /// <summary>
        /// Получить инфу о пользователях
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUserByIds(IList<int> ids)
        {
            var users = new List<User>();

            foreach (var userId in ids)
            {
                var result = await GetUserById(userId);
                if (result != null)
                    users.Add(result);
            }

            return users;
        }

        /// <inheritdoc />
        /// <summary>
        /// Получить инфу о пользователе
        /// </summary>
        /// <returns></returns>
        public async Task<IList<User>> GetAllUsers(int skip, int count)
        {
            var users = await _repository.FetchAsync(skip, count);

            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var user in users)
            {
                user.Friends = await _friendRepository.FetchAsync(f => f.UserId == user.Id);

                var tags = await _tagRepository.FetchAsync(t => t.UserId == user.Id);
                user.Tags = tags.Count == 0 ? new List<string>() : tags.Select(t => t.Name).ToList();
            }

            // ReSharper disable once PossibleMultipleEnumeration
            return users.ToList();
        }

        /// <inheritdoc />
        /// <summary>
        /// Есть ли пользователи в базе
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsUsers()
        {
            var users = await _repository.CountAsync();
            return users != 0;
        }

        /// <inheritdoc />
        /// <summary>
        /// Количество пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountUsers()
        {
            return (int)await _repository.CountAsync();
        }
    }
}
