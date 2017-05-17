#pragma once
<<<<<<< HEAD
#include "ISets.h"
#include <memory>
#include "vector"
#include "SetFactory.h"
#include "ISet.h"
=======
#include "ISet.h"
#include "ISets.h"
#include "Container.h"
>>>>>>> Update from private repository

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class Sets // todo testing
                : public ISets
        {
        private:
            std::unique_ptr<ISetFactory> m_factory;
            ISet* m_current_set;
            std::vector<ISet*> m_sets;

        public:
            Sets ( std::unique_ptr<ISetFactory> factory )
                : m_factory ( std::move ( factory ) )
            {
            }

            ~Sets ()
            {
                for (ISet* set : m_sets)
                {
                    m_factory->release(set);
                }

                m_sets.clear();
            }

            ISet* new_set () override;
            ISet* get_current_set () const override;
            ISet* operator[] ( const size_t index ) const override;
            size_t get_length () const override;
=======
        class Sets
                : public Container<ISet>
                  , public ISets
        {
        public:
            Sets ( const Hypodermic::FactoryWrapper<ISet>& factory_wrapper )
                : Container<ISet> ( factory_wrapper )
            {
            }

            ISet_Ptr create_new_set () override;
            ISet_Ptr get_current_set () const override;
            ISet_Ptr get_set_at_index ( const size_t index ) const override;
            size_t get_number_of_sets () const override;
>>>>>>> Update from private repository
        };
    };
};
