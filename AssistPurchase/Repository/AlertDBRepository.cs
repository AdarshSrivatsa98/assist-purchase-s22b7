﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchase.Models;

namespace AssistPurchase.Repository
{
    public class AlertDBRepository : IAlertRepository
    {
        List<Models.AlertDataModel> _alertdb = new List<AlertDataModel>();


        public AlertDBRepository()
        {
            _alertdb.Add(new AlertDataModel
            {
                CustomerName = "",
                CustomerEmailId = "",
                SelectedProduct = "",
                RequirementMessage = "",
                //ReplyFromSalesPerson = "",
            }
           );
        }
        public AlertDataModel AddNewUserRequest(AlertDataModel newState)
        {
            _alertdb.Add(newState);
            return _alertdb[_alertdb.Count - 1];
        }

        public IEnumerable<AlertDataModel> GetAllAlertRequests()
        {
            return _alertdb;
        }
    }
}
