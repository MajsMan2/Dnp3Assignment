using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic
{
    public class PostLogic : IPostLogic
    {
    
        private readonly IPostDao postDao;
        private readonly IUserDao userDao;

        public PostLogic(IPostDao postDao, IUserDao userDao)
        {
            this.postDao = postDao;
            this.userDao = userDao;
        }
        public async Task<Post> CreateAsync(PostCreationDto dto)
        {
            User? user = await userDao.GetByIdAsync(dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }

            Post post = new Post(user, dto.Title, dto.NewText);
            
            ValidatePost(dto);
            Post created = await postDao.CreateAsync(post);
            return created;
        }

        public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
        {
            return postDao.GetAsync(searchParameters);
        }

        private void ValidatePost(PostCreationDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        }
        public async Task UpdateAsync(PostUpdateDto dto)
        {
            Post? existing = await postDao.GetByIdAsync(dto.Id);

            if (existing == null)
            {
                throw new Exception($"Post with ID {dto.Id} not found!");
            }

            User? user = null;
            if (dto.OwnerId != null)
            {
                user = await userDao.GetByIdAsync((int)dto.OwnerId);
                if (user == null)
                {
                    throw new Exception($"User with id {dto.OwnerId} was not found.");
                }
            }

            User userToUse = user ?? existing.Owner;
            string titleToUse = dto.Title ?? existing.Title;
            string newTextToUse = dto.NewText ?? existing.NewText;
            bool completedToUse = dto.IsCompleted ?? existing.IsCompleted;


            Post updated = new (userToUse, titleToUse, newTextToUse)
            {
                IsCompleted = completedToUse,
                Id = existing.Id,
            };

            ValidatePost(updated);

            await postDao.UpdateAsync(updated);
        }

        private void ValidatePost(Post dto)
        {
            if (string.IsNullOrEmpty(dto.Title + dto.NewText)) throw new Exception("Title and text cannot be empty.");
        }
    
        public async Task DeleteAsync(int id)
        {
            Post? post = await postDao.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with ID {id} was not found!");
            }

            await postDao.DeleteAsync(id);
        }
        
        public async Task<PostBasicDto> GetByIdAsync(int id)
        {
            Post? post = await postDao.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with id {id} not found");
            }

            return new PostBasicDto(post.Id, post.Owner.UserName, post.Title, post.NewText);
        }
        
    }
}