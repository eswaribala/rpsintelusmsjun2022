using CQRSNET6Demo.Events;
using CQRSNET6Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSNET6Demo.Commands
{
    public class UpdateCustomerCommand : Command
    {
        public string CustomerName { get; set; }
        public long MobileNo { get; set; }
        public string Email { get; set; }
        public List<CreateInvoiceCommand> InvoiceList { get; set; }
        public CustomerUpdatedEvent ToCustomerEvent()
        {
            return new CustomerUpdatedEvent
            {
                CustomerId = this.Id,
                CustomerName = this.CustomerName,
                MobileNo = this.MobileNo,
                Email=this.Email,
               InvoiceList = this.InvoiceList.Select(invoice => new InvoiceCreatedEvent
                {
                    Amount = invoice.Amount,
                    DOI = invoice.DOI,
                    InvoiceNo = invoice.InvoiceNo
                }).ToList()
            };
        }
        public Customer ToCustomerRecord(Customer record)
        {
            record.CustomerName = this.CustomerName;
            record.MobileNo = this.MobileNo;
            record.Email = this.Email;
            record.InvoiceList = this.InvoiceList.Select(invoice => new Invoice
            {
                Amount = invoice.Amount,
                DOI = invoice.DOI,
                InvoiceNo = invoice.InvoiceNo
            }).ToList()
                ;
            return record;
        }
    }
}
