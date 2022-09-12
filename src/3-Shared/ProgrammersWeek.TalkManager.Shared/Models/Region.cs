﻿namespace ProgrammersWeek.TalkManager.Shared.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Talk>? Talks { get; set; }
}