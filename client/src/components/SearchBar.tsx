import React from 'react';
import { SearchIcon } from './icons';
import { MenuIcon} from './icons';
import { FilterIcon } from './icons';
export const SearchBar = () => {
    
    return (
        <div className="searchbar">
            <div className="search">
            <button className='menu-icon'>
                <MenuIcon/>
            </button>
            <input type="text" name="" id="" placeholder='Hinted search text' />
            </div>
            <div className="control-icons">
                <button className='search-icon'>
                <SearchIcon/>
                </button>

                <button className='filter-icon'>
                <FilterIcon/>
                </button>
            </div>
        </div>
    )
}