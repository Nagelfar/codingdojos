namespace DojoOLGFsharp

type Position(x:int, y:int) = struct
    member private this.X = x
    member private this.Y = y
    member this.North() = new Position(x,y+1)
    member this.South() = new Position(x,y-1)
    member this.East() = new Position(x+1,y)
    member this.West() = new Position(x-1,y)

    static member (+) (lhs:Position, rhs: Position) = new Position(lhs.X + rhs.X,lhs.Y + rhs.Y)
    static member( ~-)(position:Position) = new Position(-position.X,-position.Y)
    end

type Heading(direction:char) = struct

    member this.Move()= this.Move(new Position(0,0))
        
    member this.Move(position:Position) = 
        match direction with
            |'N' -> position.North()
            |'S' -> position.South()
            |'E' -> position.East()
            |'W' -> position.West()
            | _ -> position
    
    member this.RotateLeft() =   
        match direction with
            | 'N' -> new Heading( 'W')
            | 'E' -> new Heading( 'N')
            | 'S' -> new Heading( 'E')
            | 'W' -> new Heading( 'S')
            | _-> this

    end

type Rover(position:Position, heading:Heading) = struct
    member this.Execute(action:char) = 
        match action with
        | 'f' ->  new Rover(position + heading.Move(),heading)
        | 'b' -> new Rover(position + (-heading.Move()),heading)
        | 'l' -> new Rover(position, heading.RotateLeft())
        | 'r'->new Rover(position,heading.RotateLeft().RotateLeft().RotateLeft())
        | _->this

    end