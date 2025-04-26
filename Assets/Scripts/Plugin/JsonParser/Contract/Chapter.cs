using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Chapter
{
    string Title { get; set; }
    string Description { get; set; }
    int ChapterNumber { get; set; }
    List<Context> Sections { get; set; }
}