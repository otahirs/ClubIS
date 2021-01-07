using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace ClubIS.BusinessLayer.Tests
{
    public class EventServiceTests
    {
        private readonly IMapper _mapper = new MapperConfiguration(c =>
          c.AddProfile<AutoMapperProfile>()).CreateMapper();

        public EventEditDTO origEvent = new EventEditDTO()
        {
            Id = 42,
            StartDate = new DateTime(2020, 10, 11),
            EndDate = new DateTime(2020, 10, 11),
            Name = "HROB",
            Place = "Ještěd",
            Organizer = "OB ZAM",
            Link = "hrob.cz",
            Deadlines = new List<EventDeadline>()
            {
                new EventDeadline
                {
                    Id = 69,
                    Deadline = DateTime.Now,
                    EventId = 42,
                }
            },
            ClassOptions = new HashSet<EventClassOption>()
            {
                new EventClassOption()
                {
                    Id = 1,
                    EventId = 1,
                    Name = "A"
                },
                new EventClassOption()
                {
                    Id = 2,
                    EventId = 1,
                    Name = "B"
                }
            },
            EventType = EventType.Race,
            EventState = EventState.Archived,
            EventProperties = EventProperty.Championship,
            EventStages = new HashSet<EventStageDTO>()
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
        public async Task GetById() // db seed dependant
        {
            EventEditDTO e;
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new EventService(uow,_mapper);
                e = (await ns.GetById(1));
            }
            Assert.NotNull(e);
        }

        [Fact]
        public async Task Create()
        {
            EventEditDTO e;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EventService(uow, _mapper);
                await es.Create(origEvent);
                await uow.Save();
                e = (await es.GetById(42));
            }
            origEvent.Should().BeEquivalentTo(e);
        }

        [Fact]
        public async Task Update()
        {
            EventEditDTO e;
            var editedOrganizer = "Edited Organizer";
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EventService(uow, _mapper);
                await es.Create(origEvent);
                await uow.Save();
                e = await es.GetById(42);
                e.Organizer = editedOrganizer;
                await es.Update(e);
                await uow.Save();
                e = await es.GetById(42);
            }
            Assert.Equal(editedOrganizer, e.Organizer);
        }

        [Fact]
        public async Task Delete()
        {
            EventEditDTO e;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EventService(uow, _mapper);
                await es.Create(origEvent);
                await uow.Save();
                await es.Delete(origEvent.Id);
                await uow.Save();
                e = await es.GetById(42);
            }
            Assert.Null(e);
        }

        [Fact]
        public async Task GetAllWithUserEntry() // db seed dependant
        {
            var origEvent2 = new EventEditDTO
            {
                Id = 43,
                StartDate = new DateTime(2020,
                    10,
                    11),
                EndDate = new DateTime(2020,
                    10,
                    11),
                Name = "MČR klubů a oblastních výběrů",
                Place = "Kobyla nad Vidnávkou",
                Organizer = "OB ZAM",
                Link = "mcr2020.obopava.cz",
                Deadlines = new List<EventDeadline>(),
                Leader = null,
                ClassOptions = new HashSet<EventClassOption>()
                {
                    new EventClassOption()
                    {
                        Id = 1,
                        EventId = 1,
                        Name = "A"
                    },
                    new EventClassOption()
                    {
                        Id = 2,
                        EventId = 1,
                        Name = "B"
                    }
                },
                EventType = EventType.Race,
                EventState = EventState.Archived,
                EventProperties = EventProperty.Championship,
                EventStages = new HashSet<EventStageDTO>()
            };
            List<EventListWithUserEntryDTO> events;
            using (var uow = TestUoWFactory.Create())
            {
                var es = new EventService(uow, _mapper);
                await es.Create(origEvent);
                await es.Create(origEvent2);
                await uow.Save();
                events = (await es.GetAllWithUserEntry(userId: 2)).ToList();
            }
            using (new AssertionScope())
            {
                events.Count().Should().BeGreaterThan(1);
                var event1 = events.First(n => n.Event.Id == 42);
                event1.Event.StartDate.Should().Be(origEvent.StartDate);
                event1.Event.EndDate.Should().Be(origEvent.EndDate);
                event1.Event.Name.Should().Be(origEvent.Name);
                event1.Event.Place.Should().Be(origEvent.Place);
                Assert.Equal(event1.Event.Deadlines, origEvent.Deadlines);
                event1.Event.EventType.Should().Be(origEvent.EventType);
                Assert.Null(event1.EntryInfo);
            }
        }
    }
}
