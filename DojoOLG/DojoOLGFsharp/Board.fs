namespace DojoOLGFsharp


type BoardSize(width:int, height:int)  = 
    member this.Wrap(position:Position) = new Position(position.X % width, position.Y % height)       

