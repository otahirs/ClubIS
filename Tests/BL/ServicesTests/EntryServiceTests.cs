using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Services;
using clubIS.DataAccessLayer.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace clubIS.BusinessLayer.Tests.ServicesTests
{
    public class EntryServiceTests
    {
        public EventEntryEditDTO origEntry = new EventEntryEditDTO
        {
            Id = 42,
            UserId = 1,
            EventId = 42,
            Class = "A",
            HasClubAccommodation = false,
            HasClubTransport = false,
            NoteForClub = null,
            NoteForOrganizators = null,
            SiCardNumber = 1234,
            EnteredStages = new HashSet<EventStageDTO>()
            {
                new EventStageDTO
                {
                    EventId = 42,
                    Date = DateTime.Now,
                    Name = "null"
                }
            }
        };

        [Fact]
        public async Task Create()
        {
            EventEntryEditDTO entry;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EntryService(uow);
                await es.Create(origEntry);
                await uow.Save();
                entry = (await es.GetById(42));
            }
            origEntry.Should().BeEquivalentTo(entry);
        }

        [Fact]
        public async Task Update()
        {
            EventEntryEditDTO entry;
            var editedClass= "C";
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EntryService(uow);
                await es.Create(origEntry);
                await uow.Save();
                entry = await es.GetById(42);
                entry.Class = editedClass;
                await es.Update(entry);
                await uow.Save();
                entry = await es.GetById(42);
            }
            Assert.Equal(editedClass, entry.Class);
        }

        [Fact]
        public async Task Delete()
        {
            EventEntryEditDTO e;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EntryService(uow);
                await es.Create(origEntry);
                await uow.Save();
                await es.Delete(origEntry.Id);
                await uow.Save();
                e = await es.GetById(42);
            }
            Assert.Null(e);
        }

        [Fact]
        public async Task GetAllByEventId()
        {
            var origEntry2 = new EventEntryEditDTO
            {
                Id = 43,
                UserId = 43,
                EventId = 42,
                Class = "A",
                HasClubAccommodation = false,
                HasClubTransport = false,
                NoteForClub = null,
                NoteForOrganizators = null,
                SiCardNumber = 1234,
                EnteredStages = new HashSet<EventStageDTO>()
                {
                    new EventStageDTO
                    {
                        Date = DateTime.Now,
                        Name = "null"
                    }
                }
            };
            List<EventEntryListDTO> entries;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EntryService(uow);
                
                await es.Create(origEntry);
                await es.Create(origEntry2);
                await uow.Save();
                entries = (await es.GetAllByEventId(42)).ToList();
            }
            using (new AssertionScope())
            {
                entries.Count().Should().BeGreaterThan(1);
                var entry1 = entries.First(n => n.Id == 42);
                entry1.Class.Should().Be(origEntry.Class);
                entry1.HasClubAccommodation.Should().Be(origEntry.HasClubAccommodation);
                entry1.HasClubTransport.Should().Be(origEntry.HasClubTransport);
                entry1.NoteForClub.Should().Be(origEntry.NoteForClub);
                entry1.NoteForOrganizators.Should().Be(origEntry.NoteForOrganizators);
                entry1.SiCardNumber.Should().Be(origEntry.SiCardNumber);
                Assert.Null(entry1.Firstname);
                Assert.Null(entry1.Surname);
                Assert.Null(entry1.RegistrationNumber);
            }
        }
    }
    
}
