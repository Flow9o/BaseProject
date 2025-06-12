import {FormControl} from '@angular/forms';

type ReplaceUndefinedWithNull<T> = T extends undefined ? null : T;

export type WrappedFormControls<T> = { [k in keyof T]: FormControl<ReplaceUndefinedWithNull<T[k]>> };

/**
 * A utility type that maps each property of the given type `T` to a `FormControl`,
 * where the value of the `FormControl` allows both the original type and `null`.
 *
 * This is especially useful when working with Angular reactive forms where form fields
 * are initialized with `null`, but the original interface (e.g., from OpenAPI-generated code)
 * does not include `null` in its type definitions (e.g., `string | undefined`, not `string | null`).
 *
 * @example
 * interface Filter {
 *   id?: number;
 *   name?: string;
 * }
 *
 * // This creates a form with FormControl<number | null> and FormControl<string | null>
 * type FilterFormControls = WrappedFormControlsAllowingNull<Filter>;
 */
export type WrappedFormControlsAllowingNull<T> = {
  [K in keyof T]-?: FormControl<T[K] | null>;
};
