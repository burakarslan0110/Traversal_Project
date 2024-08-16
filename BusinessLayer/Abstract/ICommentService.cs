﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestinationByID(int id);
        List<Comment> TGetListCommentWithDestination();
        List<Comment> TGetListCommentWithDestinationAndUser(int id);
        List<Comment> TGetListCommentWithUser(int id);
    }
}
