using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Dtos;
using Shared.Models;

namespace EfcDataAccess.DAO;

public class PostEfcDao : IPostDao
{
    private readonly RedditContext context;

    public PostEfcDao(RedditContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }
    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParams)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParams.UserName))
        {
            query = query.Where(post =>
                post.Owner.UserName.ToLower().Equals(searchParams.UserName.ToLower()));
        }
        if (searchParams.UserId != null)
        {
            query = query.Where(p => p.Owner.Id == searchParams.UserId);
        }

        if (!string.IsNullOrEmpty(searchParams.TitleContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParams.TitleContains.ToLower()));
        }
        if (!string.IsNullOrEmpty(searchParams.TextContains))
        {
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchParams.TextContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
    public async Task<Post?> GetByIdAsync(int postId)
    {
        Post? found = await context.Posts
            .Include(post => post.Owner)
            .SingleOrDefaultAsync(post => post.Id == postId);
        return found;
    }
    public async Task UpdateAsync(Post toUpdate)
    {
        context.Posts.Update(toUpdate);
        await context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
        {
            throw new Exception($"Post with id {id} not found");
        }

        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }
}