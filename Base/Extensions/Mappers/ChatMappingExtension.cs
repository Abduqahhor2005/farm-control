using FarmControl.Features.Commands.Chat.ChatCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Chat.ChatViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class ChatMappingExtension
{
    public static GetChatViewModel ToReadInfo(this Chat chat)
    {
        return new()
        {
            Id = chat.Id,
            ChatBaseInfo = new()
            {
                Comment = chat.Comment,
                TalkTime = chat.TalkTime,
                FarmerId = chat.FarmerId,
                CustomerId = chat.CustomerId
            }
        };
    }
    
    public static GetChatDetailViewModel ToReadDetailInfo(this Chat chat)
    {
        return new()
        {
            Id = chat.Id,
            ChatBaseInfo = new()
            {
                Comment = chat.Comment,
                TalkTime = chat.TalkTime,
                FarmerId = chat.FarmerId,
                CustomerId = chat.CustomerId
            }
        };
    }

    public static Chat ToChat(this CreateChatRequest request)
    {
        return new()
        {
            Comment = request.ChatBaseInfo.Comment,
            TalkTime = request.ChatBaseInfo.TalkTime,
            FarmerId = request.ChatBaseInfo.FarmerId,
            CustomerId = request.ChatBaseInfo.CustomerId
        };
    }

    public static Chat ToUpdatedChat(this Chat chat, UpdateChatRequest request)
    {
        chat.Version++;
        chat.UpdatedAt = DateTime.UtcNow;
        chat.Comment = request.ChatBaseInfo.Comment;
        chat.TalkTime = request.ChatBaseInfo.TalkTime;
        chat.FarmerId = request.ChatBaseInfo.FarmerId;
        chat.CustomerId = request.ChatBaseInfo.CustomerId;
        return chat;
    }

    public static Chat ToDeletedChat(this Chat chat)
    {
        chat.IsDeleted = true;
        chat.DeletedAt = DateTime.UtcNow;
        chat.UpdatedAt = DateTime.UtcNow;
        chat.Version++;
        return chat;
    }
}