
 # film-archive-management-system

```mermaid
erDiagram
    MOVIE {
        int ID PK
        string Title
        date ReleaseDate
        string Description
        int DirectorID FK
        string imgPath
    }
    DIRECTOR {
        int ID PK
        string FirstName
        string LastName
        string Bio
        string imgPath
    }
    ACTOR {
        int ID PK
        string FirstName
        string LastName
        string imgPath
    }
    GENRE {
        int ID PK
        string Name
        string Description
        string HexColor 
    }
    MOVIE_ACTOR {
        int MovieID PK, FK
        int ActorID PK, FK
    }
    MOVIE_GENRE {
        int MovieID PK, FK
        int GenreID PK, FK
    }

    DIRECTOR ||--o{ MOVIE : directs
    MOVIE ||--o{ MOVIE_ACTOR : has
    MOVIE_ACTOR ||--|| ACTOR : includes
    MOVIE ||--o{ MOVIE_GENRE : categorized_as
    MOVIE_GENRE ||--|| GENRE : belongs_to
