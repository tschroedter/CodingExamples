#include <cstdint>
#include "include/Player.h"
#include "include/IGames.h"
#include "include/GamesCounter.h"

namespace Tennis
{
    namespace Logic
    {
        int8_t GamesCounter::count_games_for_player (
            const Player player,
<<<<<<< HEAD
            const IGames* games )
=======
            const IGames_Ptr games )
>>>>>>> Update from private repository
        {
            GameStatus game_status =
                    One == player
                        ? PlayerOneWon
                        : PlayerTwoWon;

            int8_t counter = 0;

<<<<<<< HEAD
            size_t number_of_games = games->get_length();

            for ( size_t i = 0 ; i < number_of_games ; i++ )
            {
                IGame* game = ( *games ) [ i ]; // todo should be set.game[i], mock access []
=======
            size_t number_of_games = games->get_number_of_games();

            for ( size_t i = 0 ; i < number_of_games ; i++ )
            {
                IGame_Ptr game = games->get_game_at_index ( i );
>>>>>>> Update from private repository

                if ( game_status == game->get_status() )
                {
                    counter++;
                }
            }

            return counter;
        }
    };
};
