using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Services;

public interface ISessionService
{
    public IEnumerable<Monster> Monsters { get; }
    public bool IsInitialized { get; }
    public bool HasMonsters { get; }
    public void InitializeList(IEnumerable<Monster> monsters);
    public void AddUserMonster(Monster monster);
    public void RemoveUserMonster(Monster monster);
}
