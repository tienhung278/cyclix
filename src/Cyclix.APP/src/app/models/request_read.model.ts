import {Customer} from "./customer.model";
import {Type} from "./type.model";
import {Brand} from "./brand.model";
import {Service} from "./service.model";
import {Package} from "./package.model";
import {Option} from "./option.model";
import {AnotherOption} from "./another-option.model";

export interface RequestRead {
  id?: number
  type?: Type
  brand?: Brand
  service?: Service
  packages?: Package[]
  options?: Option[]
  anotherOptions?: AnotherOption[]
  description?: string
  note?: string
  customer?: Customer
}
