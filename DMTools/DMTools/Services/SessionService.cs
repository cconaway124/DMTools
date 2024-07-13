using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Services;

public class SessionService : ISessionService
{
    private List<Monster> monsters = new();
    public IEnumerable<Monster> Monsters
    {
        get => this.monsters;
        private set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            this.monsters = value.ToList();
        }
    }

    public bool IsInitialized => this.monsters != null;

    public bool HasMonsters => this.monsters.Any();

    public void InitializeList(IEnumerable<Monster> monsters)
    {
        this.Monsters = monsters;
    }

    public void AddUserMonster(Monster monster)
    {
        this.monsters.Add(monster);
    }

    public void RemoveUserMonster(Monster monster)
    {
        this.monsters.Remove(monster);
    }
}
