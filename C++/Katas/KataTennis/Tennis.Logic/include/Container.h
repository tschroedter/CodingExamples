#pragma once
#include <memory>
#include "vector"
#include "ContainerException.h"
#include "IContainer.h"
#include <string>
#include <functional>
#include <Hypodermic/FactoryWrapper.h>

namespace Tennis
{
    namespace Logic
    {
        template <class T>
        class Container
                : public IContainer<T>
        {
        protected:
            std::function<std::shared_ptr<T> ()> m_factory;
            std::shared_ptr<T> m_current_item;
            std::vector<std::shared_ptr<T>> m_items;

        public:
            Container (
                const Hypodermic::FactoryWrapper<T>& factory_wrapper )
                : m_factory ( factory_wrapper.getFactory() )
                , m_current_item ( nullptr )
            {
            }

            std::shared_ptr<T> new_item () override;
            std::shared_ptr<T> get_current_item () const override;
            std::shared_ptr<T> operator[] ( const size_t index ) const override;
            size_t get_length () const override;
        };

        template <class T>
        std::shared_ptr<T> Container<T>::new_item ()
        {
            m_current_item = m_factory();

            m_items.push_back ( m_current_item );

            return m_current_item;
        }

        template <class T>
        std::shared_ptr<T> Container<T>::get_current_item () const
        {
            return m_current_item;
        }

        template <class T>
        std::shared_ptr<T> Container<T>::operator[] ( const size_t index ) const
        {
            if ( index < 0 || index >= m_items.size() )
            {
                throw ContainerException ( "Given index "
                                          + std::to_string ( index )
                                          + " must be >= 0 and < "
                                          + std::to_string ( m_items.size() ) );
            }

            std::shared_ptr<T> item = ( m_items.at ( index ) );

            return item;
        }

        template <class T>
        size_t Container<T>::get_length () const
        {
            return m_items.size();
        }
    };
};
