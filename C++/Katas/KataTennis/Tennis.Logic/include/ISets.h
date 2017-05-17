#pragma once
#include "ISet.h"

namespace Tennis
{
    namespace Logic
    {
        class ISets
        {
        public:
<<<<<<< HEAD
            virtual ~ISets() = default;

            virtual ISet* new_set() = 0;
            virtual ISet* get_current_set() const = 0;
            virtual ISet* operator[] (const size_t index) const = 0;
            virtual size_t get_length() const = 0;
        };
    };
};
=======
            virtual ~ISets () = default;

            virtual ISet_Ptr create_new_set () = 0;
            virtual ISet_Ptr get_current_set () const = 0;
            virtual ISet_Ptr get_set_at_index ( const size_t index ) const = 0;
            virtual size_t get_number_of_sets () const = 0;
        };

        typedef std::shared_ptr<ISets> ISets_Ptr;
    };
};
>>>>>>> Update from private repository
